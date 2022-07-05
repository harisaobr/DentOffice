// -- payment.dart --
import 'package:json_annotation/json_annotation.dart';

import 'korisnik.dart';

part 'payment.g.dart';

@JsonSerializable()
class Payment {
  int? paymentId;
  String metoda;
  DateTime datum;
  double iznos;
  int korisnikId;
  Korisnik? korisnik;

  Payment({this.paymentId,required this.metoda,required this.datum,required this.iznos,required this.korisnikId, this.korisnik,});

  factory Payment.fromJson(Map<String, dynamic> json) => _$PaymentFromJson(json);

  Map<String, dynamic> toJson() => _$PaymentToJson(this);
}