// -- racun.dart --
import 'package:json_annotation/json_annotation.dart';

import 'korisnik.dart';
import 'pregled.dart';

part 'racun.g.dart';

@JsonSerializable()
class Racun {
  int racunId;
  int? pregledId;
  int? korisnikId;
  double? ukupnaCijena;
  DateTime? datumIzdavanjaRacuna;
  bool? isPlaceno;
  Korisnik korisnik;
  Pregled pregled;
  String ukupnaCijenaFormatted;

  Racun({required this.racunId,required this.korisnikId,required this.pregledId,required this.ukupnaCijena,required this.datumIzdavanjaRacuna,required this.isPlaceno,required this.korisnik,required this.pregled,required this.ukupnaCijenaFormatted,});

  factory Racun.fromJson(Map<String, dynamic> json) => _$RacunFromJson(json);

  Map<String, dynamic> toJson() => _$RacunToJson(this);
}