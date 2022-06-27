// -- usluga.dart --
import 'package:decimal/decimal.dart';
import 'package:json_annotation/json_annotation.dart';

part 'usluga.g.dart';

@JsonSerializable()
class Usluga {
  int uslugaID;
  String naziv;
  Decimal cijena;

  Usluga({required this.uslugaID,required this.naziv,required this.cijena,});

  factory Usluga.fromJson(Map<String, dynamic> json) => _$UslugaFromJson(json);

  Map<String, dynamic> toJson() => _$UslugaToJson(this);
}