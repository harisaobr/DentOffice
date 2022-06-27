import 'package:flutter/material.dart';
import 'package:dentofficemobile/services/APIService.dart';

class Home extends StatefulWidget {
  @override
  _HomeState createState() => _HomeState();
}

class _HomeState extends State<Home> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Izbornik'),
        backgroundColor: Colors.blue,
      ),
      drawer: Drawer(
        child: ListView(
          children: [
            DrawerHeader(child: Center(child: Text('DentOffice', style: TextStyle(fontSize: 20, color: Colors.white),)),
            decoration: BoxDecoration(
              color: Colors.blue
            ),
            ),
            ListTile(
              title: Text('Termini'),
              onTap: () {
                    Navigator.of(context).pushNamed('/termini');
              },
            ),
            ListTile(
              title: Text('Odjava'),
              onTap: () {
                APIService.username = null;
                APIService.password = null;
                APIService.prijavljeniKorisnik = null;
                Navigator.of(context).pushNamed('/login');
              },
            )
          ],
        ),
      ),
    );
  }
}
