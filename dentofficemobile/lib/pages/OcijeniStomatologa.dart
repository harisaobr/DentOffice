import 'dart:convert';
import 'package:dentofficemobile/models/korisnik.dart';
import 'package:dentofficemobile/models/ocjene.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import '../services/APIservice.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';

class MojeOcjene extends StatefulWidget {
  const MojeOcjene({Key? key}) : super(key: key);

  @override
  State<MojeOcjene> createState() => _MojeOcjeneState();
}

class _MojeOcjeneState extends State<MojeOcjene> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: const Text('Moje ocjene'),
          backgroundColor: Colors.green[900],
        ),
        body: bodyWidget());
  }

  Widget bodyWidget() {
    return FutureBuilder<List<Korisnik>>(
      future: getStomatologe(),
      builder: (BuildContext context,
          AsyncSnapshot<List<Korisnik>> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const Center(child: Text('Loading..'));
        } else {
          if (snapshot.hasError) {
            return Center(child: Text('Error:${snapshot.error}'));
          } else {
            return ListView(
              children:
              snapshot.data!.map((e) => MojeOcjeneWidget(e)).toList(),
            );
          }
        }
      },
    );
  }

  Widget MojeOcjeneWidget(Korisnik) {
    return Card(
        child: Center(
            child: SingleChildScrollView(
                child: Padding(
                  padding: const EdgeInsets.all(50),
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.start,
                    children: [
                      const Text(
                        'Datum rezervacije',
                        style: TextStyle(
                            fontSize: 20, color: Colors.black, fontWeight: FontWeight.bold),
                      ),
                      const SizedBox(
                        height: 10,
                      ),
                      SizedBox(
                          height: 35,
                          child: Text(
                              DateFormat('dd.MM.yyyy')
                                  .format(Korisnik.datumRezervacije)
                                  .toString(),
                              style: const TextStyle(
                                  fontSize: 15,
                                  color: Colors.black,
                                  fontWeight: FontWeight.bold))),
                      const Text(
                        'Napomena',
                        style: TextStyle(fontSize: 20, color: Colors.black),
                      ),
                      const SizedBox(
                        height: 10,
                      ),
                      SizedBox(
                        height: 35,
                        child: Text((() {
                          if (Korisnik.napomena == "") {
                            return "/";
                          }
                          return Korisnik.napomena;
                        })(), style: const TextStyle(fontSize: 15, color: Colors.black)),
                      ),
                      const Text(
                        'Količina',
                        style: TextStyle(fontSize: 20, color: Colors.black),
                      ),
                      const SizedBox(
                        height: 10,
                      ),
                      SizedBox(
                        height: 35,
                        child: Text(Korisnik.kolicina,
                            style: const TextStyle(fontSize: 15, color: Colors.black)),
                      ),
                      const Text(
                        'Svrha',
                        style: TextStyle(fontSize: 20, color: Colors.black),
                      ),
                      const SizedBox(
                        height: 10,
                      ),
                      SizedBox(
                        height: 35,
                        child: Text((() {
                          if (Korisnik.svrhaID == 1) {
                            return "Kupovina";
                          } else if (Korisnik.svrhaID == 2) {
                            return "Uređivanje vrtova/parkova";
                          }
                          return "Aranžman";
                        })(), style: const TextStyle(fontSize: 15, color: Colors.black)),
                      ),
                      const Text(
                        'Adresa dostave',
                        style: TextStyle(fontSize: 20, color: Colors.black),
                      ),
                      const SizedBox(
                        height: 10,
                      ),
                      SizedBox(
                        height: 35,
                        child: Text(Korisnik.adresaDostave,
                            style: const TextStyle(fontSize: 15, color: Colors.black)),
                      ),
                      RatingBar.builder(
                          initialRating: 3,
                          minRating: 1,
                          direction: Axis.horizontal,
                          allowHalfRating: true,
                          itemCount: 5,
                          itemPadding: const EdgeInsets.symmetric(horizontal: 4.0),
                          itemBuilder: (context, _) => const Icon(
                            Icons.star,
                            color: Colors.amber,
                          ),
                          onRatingUpdate: (rating) async {
                            var request = Ocjene(
                              korisnikId: 1,
                              pacijentId: APIService.prijavljeniKorisnik!.korisnikID,
                              kreirano: DateTime.now(),
                              ocjena: rating,
                              komentar: '',
                              korisnik: null
                            );

                            var result = await APIService.post(
                                "Ocjena", json.encode(request.toJson()));

                            if (result != null) {
                              setState(() {
                                ScaffoldMessenger.of(context).showSnackBar(const SnackBar(
                                  content: SizedBox(
                                      height: 20,
                                      child: Center(
                                          child:
                                          Text("Uspješno ste ocjenili rezervaciju."))),
                                  backgroundColor: Color.fromARGB(255, 9, 100, 13),
                                ));
                              });
                            }
                          }),
                    ],
                  ),
                ))));
  }

  Future<List<Korisnik>> getStomatologe() async {
    Map<String, String> queryParams = Map<String, String>();
    var rez = await APIService.getById('Korisnik', queryParams);
    return rez!.map((i) => Korisnik.fromJson(i)).toList();
  }
}
