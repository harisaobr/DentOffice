// -- cocjene.dart --
import 'package:decimal/decimal.dart';
import 'package:dentofficemobile/models/payment.dart';
import 'package:json_annotation/json_annotation.dart';

import 'korisnik.dart';

part 'ocjene.g.dart';

@JsonSerializable()
class Ocjene {
  int ocjenaId;
  int korisnikId;
  DateTime kreirano;
  Decimal ocjena;
  String komentar;
  Korisnik korisnik;


  factory CreditCard.fromJson(Map<String, dynamic> json) => _$CreditCardFromJson(json);

  Map<String, dynamic> toJson() => _$CreditCardToJson(this);
}