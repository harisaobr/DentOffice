// -- korisnik_pacijent.dart --
import 'package:json_annotation/json_annotation.dart';

import 'grad.dart';
import 'korisnik.dart';
import 'pacijent.dart';
import 'uloga.dart';

part 'korisnik_pacijent.g.dart';

@JsonSerializable()
class KorisnikPacijent {
  int? gradId;
  Grad grad;
  String ime;
  String prezime;
  String email;
  List<int> slika;
  String jmbg;
  String adresa;
  String brojTelefona;
  DateTime datumRodjenja;
  String korisnickoIme;
  Uloga uloga;
  int ulogaID;
  Pacijent pacijent;
  int pacijentID;
  int korisnikID;
  Korisnik korisnici;
  bool proteza;
  bool aparatic;
  bool terapija;
  String imePrezime;

  KorisnikPacijent({required this.gradId,required this.grad,required this.ime,required this.prezime,required this.email,required this.slika,required this.jmbg,required this.adresa,required this.brojTelefona,required this.datumRodjenja,required this.korisnickoIme,required this.uloga,required this.ulogaID,required this.pacijent,required this.pacijentID,required this.korisnikID,required this.korisnici,required this.proteza,required this.aparatic,required this.terapija,required this.imePrezime,});

  factory KorisnikPacijent.fromJson(Map<String, dynamic> json) => _$KorisnikPacijentFromJson(json);

  Map<String, dynamic> toJson() => _$KorisnikPacijentToJson(this);
}