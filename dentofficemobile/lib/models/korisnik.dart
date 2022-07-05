import 'dart:convert';
import 'dart:typed_data';

import 'package:decimal/decimal.dart';
import 'package:dentofficemobile/models/pacijent_data.dart';

import 'grad.dart';
import 'uloga.dart';
import 'pacijent.dart';
import 'package:json_annotation/json_annotation.dart';


part 'korisnik.g.dart';

@JsonSerializable()
class Korisnik {
  int korisnikID;
  String ime;
  String prezime;
  String korisnickoIme;
  String email;
  String jmbg;
  String slika;
  String adresa;
  String brojTelefona;
  DateTime? datumRodjenja;
  Spol spol;
  int gradID;
  Grad? grad;
  int obavljenoPregleda;
  Uloga? uloga;
  int ulogaID;
  List<Pacijent_Data> pacijents;
  Decimal? mojaOcjena;
  Decimal? prosjecnaOcjena;

  Uint8List get slikaArray => base64Decode(slika);

  Korisnik({required this.korisnikID,required this.ime,required this.prezime,required this.korisnickoIme,required this.email,required this.jmbg,required this.slika,required this.adresa,required this.brojTelefona,required this.datumRodjenja,required this.spol,required this.gradID,required this.grad,required this.obavljenoPregleda,required this.uloga,required this.ulogaID,required this.pacijents,this.mojaOcjena, this.prosjecnaOcjena});

  factory Korisnik.fromJson(Map<String, dynamic> json) => _$KorisnikFromJson(json);

  Map<String, dynamic> toJson() => _$KorisnikToJson(this);
}

enum Spol {
  @JsonValue(0)
  musko,
  @JsonValue(1)
  zensko
}