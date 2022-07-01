import 'package:dentofficemobile/pages/RezervacijaTermina.dart';
import 'package:flutter/material.dart';
import 'package:dentofficemobile/pages/Login.dart';
import 'package:dentofficemobile/pages/Loading.dart';
import 'package:dentofficemobile/pages/Home.dart';
import 'package:dentofficemobile/pages/Termini.dart';
import 'package:flutter_stripe/flutter_stripe.dart';

import 'pages/Cjenovnik.dart';

void main() {
  Stripe.publishableKey = "pk_test_51LGmN7GBwfqh1nHltOq3tkMGzDUTEMlwHz4Onw6JTPwFMF47S60Ln0iBzJM766yIzsHN52M6b7OaLZtMwicYKnr900B24bt65p";
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
        '/rezervacija':(context)=>RezervacijaTermina()
      },
    );
  }
}

