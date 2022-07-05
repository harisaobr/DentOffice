import 'dart:async';
import 'package:dentofficemobile/models/termin.dart';
import 'package:flutter/material.dart';
import 'package:dentofficemobile/services/APIService.dart';

import '../widgets/ListViewRowWidget.dart';
import '../helper.dart';

class Termini extends StatefulWidget {
  @override
  _TerminiState createState() => _TerminiState();
}

class _TerminiState extends State<Termini> {
  List<DropdownMenuItem> items = [];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Termini'),
        backgroundColor: Colors.blue,
      ),
      body: Column(
        children: [Expanded(child: bodyWidget())],
      ),
    );
  }

  Widget bodyWidget() {
    return FutureBuilder<List<Termin>>(
        future: GetTermini(),
        builder: (BuildContext context, AsyncSnapshot<List<Termin>> snapshot) {
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
                        child: Text(
                          'Prethodni termini',
                          style: TextStyle(
                              fontFamily: 'Quicksand',
                              fontSize: 20.0,
                              color: Colors.white,
                              fontWeight: FontWeight.bold),
                          textAlign: TextAlign.left,
                        ),
                      ),
                    ),
                    FutureBuilder<List<Termin>>(
                      future: GetTermini(),
                      builder: (context, snapshot) {
                        if (snapshot.hasError) print(snapshot.error);
                        if (!snapshot.hasData)
                          return const Center(
                              child: const CircularProgressIndicator());

                        var data = snapshot.data!.where((element) =>
                            element.datumVrijeme.isBefore(DateTime.now()));

                        if (data.isEmpty) {
                          return listViewRowWidget(
                              content: 'Nemate prethodnih termina');
                        }

                        return Column(
                            children:
                                data.map((e) => TerminiWidget(e)).toList());
                      },
                    ),
                    const SizedBox(height: 10.0)
                  ],
                ),
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
                        child: Text(
                          'Nadolazeći termini',
                          style: TextStyle(
                              fontFamily: 'Quicksand',
                              fontSize: 20.0,
                              color: Colors.white,
                              fontWeight: FontWeight.bold),
                          textAlign: TextAlign.left,
                        ),
                      ),
                    ),
                    FutureBuilder<List<Termin>>(
                      future: GetTermini(),
                      builder: (context, snapshot) {
                        if (snapshot.hasError) print(snapshot.error);
                        if (!snapshot.hasData) {
                          return const Center(
                              child: CircularProgressIndicator());
                        }

                        var data = snapshot.data!.where((element) =>
                            !element.datumVrijeme.isBefore(DateTime.now()));

                        if (data.isEmpty) {
                          return listViewRowWidget(
                              content: 'Nemate nadolazećih termina');
                        }

                        return Column(
                            children:
                                data.map((e) => TerminiWidget(e)).toList());
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

  Future<List<Termin>> GetTermini() async {
    Map<String, String> queryParams = Map<String, String>();
    queryParams['PacijentId'] =
        APIService.prijavljeniKorisnik!.pacijents[0].pacijentID.toString();

    var response = await APIService.getAll('Termin', queryParams);

    List<Termin> termini =
        List<Termin>.from(response!.map((model) => Termin.fromJson(model)));
    return termini;
  }

  Widget TerminiWidget(Termin termin) {
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
                  '${termin.uslugaNaziv}\n${termin.razlog}',
                  style: const TextStyle(color: Colors.white),
                )
              ),
              Container(
                  width: double.infinity,
                child: Text(
                  Helper.formatDateTime(termin.datumVrijeme),
                  textAlign: TextAlign.right,
                  style: const TextStyle(color: Colors.white),
                )
              ),
            ],
          ),
        ),
      ),
    );
  }
}
