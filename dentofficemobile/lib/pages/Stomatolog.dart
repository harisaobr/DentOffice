import 'dart:async';

import 'package:dentofficemobile/models/korisnik.dart';
import 'package:flutter/material.dart';
import 'package:dentofficemobile/services/APIService.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';

import '../widgets/ListViewRowWidget.dart';

class Stomatolog extends StatefulWidget {
  var stomatologId;

  Stomatolog({Key? key, @required this.stomatologId}) : super(key: key);

  @override
  _StomatologState createState() => _StomatologState();
}

class _StomatologState extends State<Stomatolog> {
  List<Korisnik> items = [];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Stomatolog'),
        backgroundColor: Colors.blue,
      ),
      body: Column(
        children: [Expanded(child: bodyWidget())],
      ),
    );
  }

  Widget bodyWidget() {
    return FutureBuilder<Korisnik>(
        future: GetStomatolog(),
        builder: (BuildContext context, AsyncSnapshot<Korisnik> snapshot) {
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
              return Column(children: <Widget>[
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
                    padding: EdgeInsets.only(
                        left: 15.0, right: 15.0, top: 8.0),
                    child:  Text(
                      'Podaci o odabranom stomatologu',
                      style: TextStyle(
                          fontFamily: 'Quicksand',
                          fontSize: 20.0,
                          color: Colors.white,
                          fontWeight: FontWeight.bold),
                      textAlign: TextAlign.left,
                    ),

                  ),
                ),
                Align(
                  alignment: Alignment.topCenter,
                  child: snapshot.data!.slika.isEmpty
                      ? Image.asset(
                    'images/default.png',
                    width: 100,
                    height: 100,
                  )
                      : Image(
                      height: 130,
                      width: 130,
                      image:
                      MemoryImage(snapshot.data!.slikaArray)),
                ),
                Align(
                  alignment: Alignment.center,
                  child: Text(
                    "${snapshot.data!.ime} ${snapshot.data!.prezime}",
                    style: TextStyle(
                        fontFamily: 'Quicksand',
                        color: Colors.black,
                        fontWeight: FontWeight.bold),
                    textAlign: TextAlign.left,
                  ),
                ),

                  Stack(
                    children: <Widget>[
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
                                padding: EdgeInsets.only(
                                    left: 15.0, right: 15.0, top: 8.0),
                                child:  Text(
                                  'Preporučeni stomatolozi',
                                  style: TextStyle(
                                      fontFamily: 'Quicksand',
                                      fontSize: 20.0,
                                      color: Colors.white,
                                      fontWeight: FontWeight.bold),
                                  textAlign: TextAlign.left,
                                ),
                              ),
                            ),
                            FutureBuilder<List<Korisnik>>(
                              future: GetRecommendedStomatolozi(),
                              builder: (context, snapshot) {
                                if (snapshot.hasError)
                                  print(snapshot.error);
                                if (!snapshot.hasData)
                                  return const Center(
                                      child:
                                      const CircularProgressIndicator());

                                if (snapshot.data!.isEmpty) {
                                  return listViewRowWidget(
                                      content:
                                      'Nemate preporučenih stomatologa');
                                }

                                return Column(
                                    children: snapshot.data!
                                        .map((e) => KorisnikWidget(e))
                                        .toList());
                              },
                            )
                          ]),
                    ],
                  )

              ]);
            }
          }
        });
  }

  Future<List<Korisnik>> GetRecommendedStomatolozi() async {
    var response = await APIService.getById('Recommender', widget.stomatologId);
    List<Korisnik> stomatolozi =
        List<Korisnik>.from(response!.map((model) => Korisnik.fromJson(model)));
    return stomatolozi;
  }

  Future<Korisnik> GetStomatolog() async {
    var response = await APIService.getById('Korisnik', widget.stomatologId);
    return Korisnik.fromJson(response);
  }

  Widget KorisnikWidget(Korisnik korisnik) {
    return Card(
      color: const Color.fromRGBO(51, 169, 255, 1),
      margin: EdgeInsets.zero,
      child: TextButton(
        onPressed: () {},
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
                  initialRating: korisnik.prosjecnaOcjena != null
                      ? double.parse(korisnik.prosjecnaOcjena.toString())
                      : 0,
                  minRating: 0,
                  direction: Axis.horizontal,
                  allowHalfRating: true,
                  ignoreGestures: true,
                  itemCount: 5,
                  itemPadding: const EdgeInsets.symmetric(horizontal: 4.0),
                  itemBuilder: (context, _) => const Icon(
                    Icons.star,
                    color: Colors.amber,
                  ),
                  onRatingUpdate: (rating) async { }),
            ],
          ),
        ),
      ),
    );
  }
}
