import 'dart:async';
import 'package:dentofficemobile/models/termin.dart';
import 'package:dentofficemobile/models/usluga.dart';
import 'package:flutter/material.dart';
import 'package:dentofficemobile/services/APIService.dart';

import '../widgets/ListViewRowWidget.dart';
import '../helper.dart';

class Usluge extends StatefulWidget {
  @override
  _UslugeState createState() => _UslugeState();
}

class _UslugeState extends State<Usluge> {
  List<DropdownMenuItem> items = [];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Cjenovnik'),
        backgroundColor: Colors.blue,
      ),
      body: Column(
        children: [Expanded(child: bodyWidget())],
      ),
    );
  }

  Widget bodyWidget() {
    return FutureBuilder<List<Usluga>>(
        future: GetUsluge(),
        builder: (BuildContext context, AsyncSnapshot<List<Usluga>> snapshot) {
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
                          color: Color.fromRGBO(51, 136, 255, 1)),
                      child: const Padding(
                        padding:
                        EdgeInsets.only(left: 15.0, right: 15.0, top: 8.0),
                        child: Text(
                          'Cjenovnik',
                          style: TextStyle(
                              fontFamily: 'Quicksand',
                              fontSize: 20.0,
                              color: Colors.white,
                              fontWeight: FontWeight.bold),
                          textAlign: TextAlign.left,
                        ),
                      ),
                    ),
                    FutureBuilder<List<Usluga>>(
                      future: GetUsluge(),
                      builder: (context, snapshot) {
                        if (snapshot.hasError) print(snapshot.error);
                        if (!snapshot.hasData) {
                          return const Center(
                              child: CircularProgressIndicator());
                        }

                        var data = snapshot.data!;

                        if (data.isEmpty) {
                          return listViewRowWidget(
                              content: 'Nema dostupnih podataka');
                        }

                        return Column(
                            children:
                            data.map((e) => UslugeWidget(e)).toList());
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

  Future<List<Usluga>> GetUsluge() async {
    Map<String, String> queryParams = Map<String, String>();

    var response = await APIService.getAll('Usluga', queryParams);

    List<Usluga> usluge =
    List<Usluga>.from(response!.map((model) => Usluga.fromJson(model)));
    return usluge;
  }

  Widget UslugeWidget(Usluga usluga) {
    return Card(
      color: const Color.fromRGBO(255, 255, 255, 1),
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
                    usluga.naziv,
                    style: const TextStyle(color: Colors.black),
                  )
              ),
              Container(
                  width: double.infinity,
                  child: Text(
                    usluga.cijena.toString() + ' KM',
                    textAlign: TextAlign.right,
                    style: const TextStyle(color: Colors.black),
                  )
              ),
            ],
            /* child: Row(
            children: [
              Expanded(

              ),
            ],
          ),*/
          ),
        ),
      ),
    );
  }
}
