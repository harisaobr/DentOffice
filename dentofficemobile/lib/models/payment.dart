// -- payment.dart --
import 'package:json_annotation/json_annotation.dart';

import 'credit_card.dart';
import 'korisnik.dart';

part 'payment.g.dart';

@JsonSerializable()
class Payment {
  int? paymentId;
  CreditCard? creditCard;
  int? creditCardId;
  String metoda;
  DateTime datum;
  double iznos;
  int korisnikId;
  Korisnik? korisnik;

  Payment({this.paymentId, this.creditCard, this.creditCardId,required this.metoda,required this.datum,required this.iznos,required this.korisnikId, this.korisnik,});

  factory Payment.fromJson(Map<String, dynamic> json) => _$PaymentFromJson(json);

  Map<String, dynamic> toJson() => _$PaymentToJson(this);
}