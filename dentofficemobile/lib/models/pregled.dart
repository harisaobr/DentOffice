// -- pregled.dart --
import 'package:json_annotation/json_annotation.dart';

import 'dijagnoza.dart';
import 'korisnik.dart';
import 'termin.dart';
import 'lijek.dart';

part 'pregled.g.dart';

@JsonSerializable()
class Pregled {
  int pregledID;
  int trajanjePregleda;
  String napomena;
  int korisnikId;
  Korisnik korisnik;
  String doktorIme;
  int terminId;
  Termin termin;
  String terminImePacijenta;
  String terminRazlog;
  String terminZavrsen;
  int lijekId;
  Lijek lijek;
  String lijekTekst;
  int dijagnozaId;
  Dijagnoza dijagnoza;
  String dijagnozaTekst;
  String pregledIme;

  Pregled({required this.pregledID,required this.trajanjePregleda,required this.napomena,required this.korisnikId,required this.korisnik,required this.doktorIme,required this.terminId,required this.termin,required this.terminImePacijenta,required this.terminRazlog,required this.terminZavrsen,required this.lijekId,required this.lijek,required this.lijekTekst,required this.dijagnozaId,required this.dijagnoza,required this.dijagnozaTekst,required this.pregledIme,});

  factory Pregled.fromJson(Map<String, dynamic> json) => _$PregledFromJson(json);

  Map<String, dynamic> toJson() => _$PregledToJson(this);
}