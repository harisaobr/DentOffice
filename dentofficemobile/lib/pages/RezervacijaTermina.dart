import 'dart:convert';
import 'dart:core';

import 'package:dentofficemobile/models/payment.dart';
import 'package:dentofficemobile/models/termin.dart';
import 'package:dentofficemobile/models/usluga.dart';
import 'package:dentofficemobile/pages/Termini.dart';
import 'package:dentofficemobile/services/APIService.dart';
import 'package:flutter/material.dart';
import 'package:flutter_stripe/flutter_stripe.dart' as flutter_stripe;
import 'package:intl/intl.dart';
import 'package:http/http.dart' as http;

class RezervacijaTermina extends StatelessWidget {
  const RezervacijaTermina({Key? key}) : super(key: key);


  @override
  Widget build(BuildContext context) {
    return const MaterialApp(
      debugShowCheckedModeBanner: false,
      home: TextScreen(),
    );
  }
}

class TextScreen extends StatefulWidget {
  const TextScreen({
    Key? key,
  }) : super(key: key);

  @override
  State<TextScreen> createState() => _TextScreenState();
}

class _TextScreenState extends State<TextScreen> {
  TextEditingController razlogController = new TextEditingController();

  DateTime selectedDate = DateTime.now();
  TimeOfDay selectedTime = TimeOfDay.now();
  bool showDate = false;
  bool showTime = false;

  List<VrijemeTermina> availableSlots = List.empty();

  bool? checkedValue = false;

  List<Usluga> uslugeList = List.empty();

  Usluga? selectedUsluga;

  var paymentIntentData;

  Future<DateTime> _selectDate(BuildContext context) async {
    var now = DateTime.now();
    var todayMidnight = DateTime(now.year, now.month, now.day);
    if(selectedDate.isBefore(now)) {
      selectedDate = now;
    }

    showDate = showTime = false;
    final selected = await showDatePicker(
      context: context,
      initialDate: selectedDate,
      firstDate: todayMidnight,
      selectableDayPredicate: (x)=>x.weekday >= 1 && x.weekday <= 6,
      lastDate: DateTime.now().add(const Duration(days: 60)),
    );
    if (selected != null && selected != selectedDate) {
      setState(() {
        selectedDate = selected;
      });
    }
    return selectedDate;
  }

  Future _selectDateTime(BuildContext context) async {
    final date = await _selectDate(context);
    setState(() {
      selectedDate = DateTime(
        date.year,
        date.month,
        date.day,
      );

    });

    final startTime = const TimeOfDay(hour: 8, minute: 0);
    final endTime = const TimeOfDay(hour: 15, minute: 30);
    final step = const Duration(minutes: 30);

    var zauzetiTermini = await GetTermini();
    setState(() {
      availableSlots = getTimes(date, startTime, endTime, step, zauzetiTermini).toList();
    });

  }
  Iterable<VrijemeTermina> getTimes(DateTime date, TimeOfDay startTime, TimeOfDay endTime, Duration step, List<Termin> zauzetiTermini) sync* {
    var hour = startTime.hour;
    var minute = startTime.minute;

    do {
      DateTime cmp = DateTime(date.year, date.month, date.day, hour, minute);
      if(cmp.isAfter(DateTime.now().add(const Duration(hours: 1)))) {
        yield VrijemeTermina(!zauzetiTermini.any((element) =>
        element.datumVrijeme
            .difference(cmp)
            .inSeconds
            .abs() < 60), TimeOfDay(hour: hour, minute: minute));
      }
      minute += step.inMinutes;
      while (minute >= 60) {
        minute -= 60;
        hour++;
      }
    } while (hour < endTime.hour ||
        (hour == endTime.hour && minute <= endTime.minute));
  }

  String getDate() {
    if (selectedDate == null) {
      return 'Odaberite datum termina';
    } else {
      return DateFormat('yyyy-MM-dd').format(selectedDate);
    }
  }

  String getDateTime() {
    if (selectedDate == null) {
      return 'Odaberite vrijeme termina';
    } else {
      return DateFormat('yyyy-MM-dd HH:mm a').format(selectedDate);
    }
  }

  String getTime(TimeOfDay tod) {
    final now = DateTime.now();

    final dt = DateTime(now.year, now.month, now.day, tod.hour, tod.minute);
    final format = DateFormat.jm();
    return format.format(dt);
  }
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Rezervacija termina'),
        centerTitle: true,
        backgroundColor: Colors.blue,
      ),
      body: SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          mainAxisAlignment: MainAxisAlignment.start,
          children: [
            Container(
              padding: const EdgeInsets.symmetric(horizontal: 15),
              width: double.infinity,
              child: ElevatedButton(
                onPressed: () {
                  _selectDateTime(context);
                  showDate = true;
                },
                child: showDate ? Text('Izmijenite termin') : Text('Odaberite termin'),
              ),
            ),
            showDate && !showTime
                ? Center(child: Text("Datum termina: ${getDate()}"))
                : const SizedBox(),
            showDate && showTime
                ? Center(child: Text("Datum i vrijeme termina: ${getDateTime()}"))
                : const SizedBox(),
            showDate && !showTime
                ?
            (availableSlots.isEmpty ?
            Container(
                margin: const EdgeInsets.all(20),
                width: double.infinity,
                child: const Center(child: Text('Nema dostupnih termina'))
            ) :
            ListView.builder(
                itemCount: availableSlots.length,

                scrollDirection: Axis.vertical,

                shrinkWrap: true, // <- added
                primary: false, // <- added
                itemBuilder: (context,index)=>

                    Card(
                        margin: EdgeInsets.zero,
                        child:
                        TextButton(
                          onPressed: () async {
                            if(availableSlots[index].dostupno){
                              setState(() {
                                selectedTime = availableSlots[index].vrijeme;
                                selectedDate = DateTime(selectedDate.year, selectedDate.month, selectedDate.day, selectedTime.hour, selectedTime.minute);
                                showTime = true;
                              });

                              if(uslugeList.isEmpty){
                                var list = await GetUsluge();
                                setState(() {
                                  uslugeList = list;
                                });
                              }
                            }
                            else {
                              showDialog(
                                  context: context,
                                  builder: (_) => AlertDialog(
                                    title: const Text('Greška'),
                                    content: const Text("Termin je zauzet."),
                                    actions: [
                                      TextButton(
                                          child: const Text("OK"),
                                          onPressed: () => Navigator.of(context, rootNavigator: true).pop('dialog')
                                      ),
                                    ],

                                  )
                              );
                            }

                          },
                          child: Padding(
                            padding: const EdgeInsets.all(2),
                            child: Row(
                              children: [
                                Expanded(
                                  child: Text(
                                    "${availableSlots[index].vrijeme.format(context)}\n${availableSlots[index].dostupno ? "Odaberite" : "Zauzet"} termin",
                                    style: TextStyle(color: availableSlots[index].dostupno ? Colors.black : Colors.red, fontSize: 16, fontWeight: FontWeight.w400),
                                  ),
                                ),
                              ],
                            ),
                          ),
                        )
                    )
            )
            ): const SizedBox(),
            showDate && showTime ?
            Center(
                child:
                DropdownButton<Usluga>(
                  hint: Text('Unesite uslugu'),
                  value: selectedUsluga,
                  items: uslugeList.map((Usluga value) {
                    return DropdownMenuItem<Usluga>(
                      value: value,
                      child: SizedBox(
                        width: 200.0, // for example
                        child: Text(value.naziv, textAlign: TextAlign.center),
                      ),
                    );
                  }).toList(),
                  onChanged: (Usluga? value) {
                    setState(() {
                      selectedUsluga = value;
                    });
                  },
                )) : const SizedBox(),

            showDate && showTime ?
            Container(
                margin: EdgeInsets.all(15),
                child:TextField(
              controller: razlogController,
              decoration: InputDecoration(
                  border: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(20),
                      borderSide: BorderSide(color: Colors.lightBlue)),
                  focusColor: Colors.blue,
                  hintText: 'Razlog termina'),
            )) : const SizedBox(),
            showDate && showTime ?
            CheckboxListTile(
              title: Text("Da li je termin hitan?"),
              value: checkedValue,
              onChanged: (newValue) {
                setState(() {
                  checkedValue = newValue;
                });
              },
              controlAffinity: ListTileControlAffinity.leading,  //  <-- leading Checkbox
            ) : const SizedBox(),
            showDate && showTime ?
            Container(
              margin: EdgeInsets.all(15),
              height: 60,
              width: double.infinity,
              decoration: BoxDecoration(
                  color: Colors.lightBlue,
                  borderRadius: BorderRadius.circular(20)),
              child:  TextButton(
                  onPressed: () async {
                    var request = Termin(
                      odobreno: checkedValue,
                      datumVrijeme: selectedDate,
                      naCekanju: true,
                      pacijentId: APIService.prijavljeniKorisnik!.pacijents[0].pacijentID,
                      razlog: razlogController.text,
                      uslugaId: selectedUsluga?.uslugaID ?? 0,
                    );

                    var error = validateTermin(request);
                    if(error != ''){
                      showDialog(
                          context: context,
                          builder: (_) => AlertDialog(
                            title: const Text('Greška'),
                            content: Text(error),
                            actions: [
                              TextButton(
                                  child: const Text("OK"),
                                  onPressed: () => Navigator.of(context, rootNavigator: true).pop('dialog')
                              ),
                            ],

                          )
                      );
                      return;
                    }

                    var response = await APIService.post(
                        "Termin", json.encode(request.toJson()));
                    if(response != null){
                      var termin = Termin.fromJson(response);

                      ScaffoldMessenger.of(context).showSnackBar(const SnackBar(
                        content: SizedBox(
                            height: 20, child: Center(child: Text("Uspješno"))),
                        backgroundColor: Color.fromARGB(255, 9, 100, 13),
                      ));

                      makePayment(double.parse(selectedUsluga!.cijena.toString()));
                    }
                  },
                  child: saveButton()),
            ) : SizedBox(),
          ],
        ),
      ),
    );
  }
  Future<List<Termin>> GetTermini() async {
    Map<String, String> queryParams = Map<String, String>();
    var response = await APIService.getAll('Termin', queryParams);
    List<Termin> termini =
    List<Termin>.from(response!.map((model) => Termin.fromJson(model)));
    return termini;
  }

  Future<List<Usluga>> GetUsluge() async {
    Map<String, String> queryParams = Map<String, String>();
    var response = await APIService.getAll('Usluga', queryParams);
    List<Usluga> usluge =
    List<Usluga>.from(response!.map((model) => Usluga.fromJson(model)));
    return usluge;
  }

  validateTermin(Termin termin) {
    if(termin.uslugaId == 0) {
      return 'Odaberite uslugu';}
    if(termin.razlog == ''){
      return 'Unesite razlog pregleda';}
    return '';
  }

  Future<void> makePayment(double iznos) async {
    try {
      paymentIntentData =
      await createPaymentIntent((iznos * 100).round().toString(), 'bam');
      await flutter_stripe.Stripe.instance
          .initPaymentSheet(
          paymentSheetParameters: flutter_stripe.SetupPaymentSheetParameters(
              paymentIntentClientSecret:
              paymentIntentData!['client_secret'],
              applePay: true,
              googlePay: true,
              testEnv: true,
              style: ThemeMode.dark,
              merchantCountryCode: 'BIH',
              merchantDisplayName: 'Dent Office'))
          .then((value) {});

      ///now finally display payment sheeet
      displayPaymentSheet(iznos);
    } catch (e, s) {
      print('exception:$e$s');
    }
  }

  createPaymentIntent(String amount, String currency) async {
    try {
      Map<String, dynamic> body = {
        'amount': amount,
        'currency': currency,
        'payment_method_types[]': 'card'
      };

      var response = await http.post(
          Uri.parse('https://api.stripe.com/v1/payment_intents'),
          body: body,
          headers: {
            'Authorization': 'Bearer sk_test_51LGmN7GBwfqh1nHlbEdpiWgXfGiiLfHToRtCJFNyeLA8H7wMztOR2ZJYYuDHgVYKhlNi9l5SwGbMKd0N5x2Py91U00ke3FfmeD',
            'Content-Type': 'application/x-www-form-urlencoded'
          });
      return jsonDecode(response.body);
    } catch (err) {
      print('err charging user: ${err.toString()}');
    }
  }

  insertUplata(double amount) async {
    var request = Payment(
        korisnikId: APIService.prijavljeniKorisnik!.korisnikID,
        iznos: amount,
        datum: DateTime.now(),
        metoda: "credit_card"
    );

    await APIService.post("Payment", json.encode(request.toJson()));
  }

  displayPaymentSheet(double iznos) async {
    try {
      await flutter_stripe.Stripe.instance
          .presentPaymentSheet(
          parameters: flutter_stripe.PresentPaymentSheetParameters(
            clientSecret: paymentIntentData!['client_secret'],
            confirmPayment: true,
          ))
          .onError((error, stackTrace) {
        print('Exception/DISPLAYPAYMENTSHEET==> $error $stackTrace');
      });

      await insertUplata(iznos);

      ScaffoldMessenger.of(context).showSnackBar(const SnackBar(
        content: SizedBox(
            height: 20, child: Center(child: Text("Uplata uspješna."))),
        backgroundColor: Color.fromARGB(255, 9, 100, 13),
      ));
      Navigator.push(
          context,
          MaterialPageRoute(
              builder: (context) => Termini()
          )
      );
    } on flutter_stripe.StripeException catch (e) {
      showDialog(
          context: context,
          builder: (_) => const AlertDialog(
            content: Text("Poništena transakcija."),
          ));
    } catch (e) {
      print('$e');
    }
  }

}
Widget saveButton() {
  return Container(
    height: 50,
    width: double.infinity,
    child: Center(
      child: Text('Potvrdi',
          style: TextStyle(
              color: Colors.white,
              fontSize: 20,
              fontWeight: FontWeight.bold)),
    ),
  );
}
class VrijemeTermina {
  bool dostupno;
  TimeOfDay vrijeme;

  VrijemeTermina(this.dostupno, this.vrijeme);
}

