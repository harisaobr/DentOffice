import 'dart:convert';
import 'dart:core';

import 'package:decimal/decimal.dart';
import 'package:dentofficemobile/main.dart';
import 'package:dentofficemobile/models/termin.dart';
import 'package:dentofficemobile/models/usluga.dart';
import 'package:dentofficemobile/pages/OnlinePlacanje.dart';
import 'package:dentofficemobile/services/APIService.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';


void main() {
  runApp(const RezervacijaTermina());
}

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

  Future<DateTime> _selectDate(BuildContext context) async {
    var now = DateTime.now();
    var todayMidnight = DateTime(now.year, now.month, now.day);
    if(selectedDate.isBefore(now))
      selectedDate = now;

    showDate = showTime = false;
    final selected = await showDatePicker(
      context: context,
      initialDate: selectedDate,
      firstDate: todayMidnight,
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
    if (date == null) return;
    setState(() {
      selectedDate = DateTime(
        date.year,
        date.month,
        date.day,
      );

    });

    final startTime = TimeOfDay(hour: 8, minute: 0);
    final endTime = TimeOfDay(hour: 15, minute: 30);
    final step = Duration(minutes: 30);

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

      yield VrijemeTermina(!zauzetiTermini.any((element) => element.datumVrijeme.difference(cmp).inSeconds.abs() < 60), TimeOfDay(hour: hour, minute: minute));
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
            TextField(
              controller: razlogController,
              decoration: InputDecoration(
                  border: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(20),
                      borderSide: BorderSide(color: Colors.lightBlue)),
                  focusColor: Colors.blue,
                  hintText: 'Razlog termina'),
            ) : const SizedBox(),
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
              height: 60,
              width: 300,
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
                      Navigator.push(
                          context,
                          MaterialPageRoute(
                              builder: (context) => const OnlinePlacanje(
                                //termin.terminID
                              )
                          )
                      );
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


}
Widget saveButton() {
  return Container(
    height: 50,
    width: 120,
    decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(17), color: Colors.blue),
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

