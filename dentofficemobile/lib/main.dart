import 'package:dentofficemobile/pages/OnlinePlacanje.dart';
import 'package:dentofficemobile/pages/RezervacijaTermina.dart';
import 'package:flutter/material.dart';
import 'package:dentofficemobile/pages/Login.dart';
import 'package:dentofficemobile/pages/Loading.dart';
import 'package:dentofficemobile/pages/Home.dart';
import 'package:dentofficemobile/pages/Termini.dart';

import 'pages/Cjenovnik.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home:Login(),
      routes: {
        '/login':(context)=>Login(),
        '/loading':(context)=>Loading(),
        '/home':(context)=>Home(),
        '/termini':(context)=>Termini(),
        '/cjenovnik':(context)=>Usluge(),
        '/rezervacija':(context)=>RezervacijaTermina(),
        '/placanje':(context)=>OnlinePlacanje(),
      },
    );
  }
}

