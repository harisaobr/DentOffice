import 'package:decimal/decimal.dart';
import 'package:dentofficemobile/models/korisnik.dart';
import 'package:dentofficemobile/models/ocjene.dart';

part of 'ocjene.dart';


Ocjene _$OcjeneFromJson(Map<String, dynamic> json) => Ocjene(
  ocjenaId: json['ocjenaId'] as int?,
  korisnikId: json['korisnikId'] as int,
  pacijentId: json['pacijentId'] as int,
  kreirano: DateTime.parse(json['kreirano'] as String),
  ocjena: Decimal.fromJson(json['ocjena'].toString()),
  komentar: json['komentar'] as String,
  korisnik: Korisnik.fromJson(json['korisnik'] as Map<String, dynamic>)
);

Map<String, dynamic> _$OcjeneToJson(Ocjene instance) => <String, dynamic>{
  'ocjenaId': instance.ocjenaId,
  'korisnikId': instance.korisnikId,
  'pacijentId': instance.pacijentId,
  'kreirano': instance.kreirano.toIso8601String(),
  'ocjena': instance.ocjena,
  'komentar': instance.komentar,
  'korisnik': instance.korisnik,
};
