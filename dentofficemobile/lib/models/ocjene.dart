// -- cocjene.dart --
import 'package:decimal/decimal.dart';
import 'package:json_annotation/json_annotation.dart';

import 'korisnik.dart';

part'ocjene.g.dart';

@JsonSerializable()
class Ocjene {
  int? ocjenaId;
  int korisnikId;
  int pacijentId;
  DateTime kreirano;
  Decimal ocjena;
  String komentar;
  Korisnik? korisnik;

  Ocjene({this.ocjenaId, required this.korisnikId, required this.pacijentId, required this.kreirano,
    required this.ocjena,required this.komentar, this.korisnik});


  factory Ocjene.fromJson(Map<String, dynamic> json) => _$OcjeneFromJson(json);

  Map<String, dynamic> toJson() => _$OcjeneToJson(this);
}