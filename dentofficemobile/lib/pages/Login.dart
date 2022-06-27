import 'package:dentofficemobile/models/korisnik.dart';
import 'package:flutter/material.dart';
import 'package:dentofficemobile/services/APIService.dart';

class Login extends StatefulWidget {
  @override
  _LoginState createState() => _LoginState();
}

class _LoginState extends State<Login> {
  TextEditingController usernameController = new TextEditingController();
  TextEditingController passwordController = new TextEditingController();

  Future<void> GetProfil() async {
    var result = await APIService.getById('Korisnik', 'Profil');
    if(result != null) {
      APIService.prijavljeniKorisnik = Korisnik.fromJson(result);
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: ListView(
      children: [
        Padding(
          padding: EdgeInsets.all(60),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Row(
                children: [
                  Text(
                    'DentOffice',
                    style: TextStyle(fontSize: 30),
                      textAlign: TextAlign.center,
                  )
                ],
              ),
              SizedBox(
                height: 20,
              ),
              TextField(
                controller: usernameController,
                decoration: InputDecoration(
                    border: OutlineInputBorder(
                        borderRadius: BorderRadius.circular(20),
                        borderSide: BorderSide(color: Colors.lightBlue)),
                    hintText: 'Korisničko ime'),
              ),
              SizedBox(
                height: 20,
              ),
              TextField(
                controller: passwordController,
                decoration: InputDecoration(
                    border: OutlineInputBorder(
                        borderRadius: BorderRadius.circular(20),
                        borderSide: BorderSide(color: Colors.lightBlue)),
                    focusColor: Colors.blue,
                    hintText: 'Šifra'),
              ),
              SizedBox(
                height: 20,
              ),
              Container(
                height: 60,
                width: 300,
                decoration: BoxDecoration(
                    color: Colors.lightBlue,
                    borderRadius: BorderRadius.circular(20)),
                child: TextButton(
                  onPressed: () async {
                    APIService.username = usernameController.text;
                    APIService.password = passwordController.text;
                    await GetProfil();

                    var error = '';
                    if (APIService.prijavljeniKorisnik == null) {
                      error = 'Niste unijeti ispravne podatke za prijavu';
                    } else if(APIService.prijavljeniKorisnik!.pacijents.isEmpty) {
                      error = 'Prijava je omogućena samo pacijentima.';
                    } else {
                      Navigator.of(context).pushReplacementNamed('/home');
                      return;
                    }

                    showDialog(
                        context: context,
                        builder: (_) => AlertDialog(
                          title: const Text('Greška'),
                          content: Text(error),
                          actions: [
                            TextButton(
                              child: const Text("OK"),
                              onPressed: () => Navigator.pop(context)
                            ),
                          ],

                        )
                    );
                    APIService.prijavljeniKorisnik = null;
                    APIService.username = null;
                    APIService.password = null;
                  },
                  child: Text(
                    'Login',
                    style: TextStyle(color: Colors.white, fontSize: 20),
                  ),
                ),
              )
            ],
          ),
        ),
      ],
    ));
  }
}
