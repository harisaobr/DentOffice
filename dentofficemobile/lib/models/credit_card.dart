// -- credit_card.dart --
import 'package:dentofficemobile/models/payment.dart';
import 'package:json_annotation/json_annotation.dart';

import 'korisnik.dart';

part 'credit_card.g.dart';

@JsonSerializable()
class CreditCard {
  int creditCardId;
  int korisnikId;
  String ime;
  Korisnik korisnik;
  List<Payment> payments;

  CreditCard({required this.creditCardId,required this.korisnikId,required this.ime,required this.korisnik,required this.payments,});

  factory CreditCard.fromJson(Map<String, dynamic> json) => _$CreditCardFromJson(json);

  Map<String, dynamic> toJson() => _$CreditCardToJson(this);
}