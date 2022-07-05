import 'dart:convert';
import 'package:decimal/decimal.dart';
import 'package:dentofficemobile/models/korisnik.dart';
import 'package:dentofficemobile/models/ocjene.dart';
import 'package:dentofficemobile/pages/Stomatolog.dart';
import 'package:dentofficemobile/widgets/ListViewRowWidget.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:dentofficemobile/services/APIService.dart';
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
          backgroundColor: Colors.blue,
        ),
        body: bodyWidget());
  }

  Widget bodyWidget() {
    return FutureBuilder<List<Korisnik>>(
        future: getStomatologe(),
        builder:
            (BuildContext context, AsyncSnapshot<List<Korisnik>> snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return const Center(child: Text('Loading..'));
          } else {
            if (!snapshot.hasData) {
              return const Center(child: CircularProgressIndicator());
            }
          }

          var data = snapshot.data!;

          if (data.isEmpty) {
            return listViewRowWidget(content: 'Nema dostupnih podataka');
          }
          return ListView(
            children: data.map((e) => KorisnikWidget(e)).toList(),
          );
        });
  }

  Widget MojeOcjeneWidget() {
    return FutureBuilder<List<Korisnik>>(
        future: getStomatologe(),
        builder:
            (BuildContext context, AsyncSnapshot<List<Korisnik>> snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return const Center(
              child: Text('Loading...'),
            );
          } else {
            if (snapshot.hasError) {
              return Center(
                child: Text('${snapshot.error}'),
              );
            } else {
              return ListView(children: <Widget>[
                Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: <Widget>[
                    const SizedBox(height: 10.0),
                    Container(
                      height: 40.0,
                      width: double.infinity,
                      decoration: const BoxDecoration(
                          borderRadius: BorderRadius.only(
                              topLeft: Radius.circular(25),
                              topRight: Radius.circular(25)),
                          color: Color.fromRGBO(51, 136, 255, 1)),
                      child: const Padding(
                        padding:
                            EdgeInsets.only(left: 15.0, right: 15.0, top: 8.0),
                      ),
                    ),
                    Builder(
                      builder: (context) {
                        if (snapshot.hasError) print(snapshot.error);
                        if (!snapshot.hasData)
                          return const Center(
                              child: const CircularProgressIndicator());

                        return Column(
                            children: snapshot.data!
                                .map((e) => KorisnikWidget(e))
                                .toList());
                      },
                    ),
                    const SizedBox(height: 10.0)
                  ],
                ),
              ]);
            }
          }
        });
  }

  Future<List<Korisnik>> getStomatologe() async {
    Map<String, String> queryParams = Map<String, String>();
    queryParams["showStomatologe"] = "True";
    queryParams["showMojeOcjene"] = "True";

    var rez = await APIService.getAll('Korisnik', queryParams);
    return rez!.map((i) => Korisnik.fromJson(i)).toList();
  }

  Widget KorisnikWidget(Korisnik korisnik) {
    return Card(
      color: const Color.fromRGBO(51, 169, 255, 1),
      margin: EdgeInsets.zero,
      child: TextButton(
        onPressed: () {
          Navigator.push(
              context,
              MaterialPageRoute(
                  builder: (context) => Stomatolog(stomatologId: korisnik.korisnikID)
              )
          );
        },
        child: Padding(
          padding: const EdgeInsets.all(10),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            mainAxisAlignment: MainAxisAlignment.start,
            children: <Widget>[
              Container(
                  width: double.infinity,
                  child: Text(
                    '${korisnik.ime} ${korisnik.prezime}',
                    style: const TextStyle(color: Colors.white),
                  )),
              RatingBar.builder(
                  initialRating: korisnik.mojaOcjena != null
                      ? double.parse(korisnik.mojaOcjena.toString())
                      : 0,
                  minRating: 0,
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
                        korisnikId: korisnik.korisnikID,
                        pacijentId: APIService
                            .prijavljeniKorisnik!.pacijents[0].pacijentID,
                        kreirano: DateTime.now(),
                        ocjena: Decimal.fromJson(rating.toString()),
                        komentar: 'test');

                    var result = await APIService.post(
                        "Ocjene", json.encode(request.toJson()));

                    if (result != null) {
                      setState(() {
                        ScaffoldMessenger.of(context)
                            .showSnackBar(const SnackBar(
                          content: SizedBox(
                              height: 20,
                              child: Center(
                                  child: Text(
                                      "Uspješno ste ocjenili stomatologa."))),
                          backgroundColor: Color.fromARGB(255, 9, 100, 13),
                        ));
                      });
                    }
                  }),
            ],
          ),
        ),
      ),
    );
  }
}
