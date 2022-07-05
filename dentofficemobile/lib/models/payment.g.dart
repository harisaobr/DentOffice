// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'payment.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Payment _$PaymentFromJson(Map<String, dynamic> json) => Payment(
      paymentId: json['paymentId'] as int?,
      metoda: json['metoda'] as String,
      datum: DateTime.parse(json['datum'] as String),
      iznos: (json['iznos'] as num).toDouble(),
      korisnikId: json['korisnikId'] as int,
      korisnik: json['korisnik'] == null
          ? null
          : Korisnik.fromJson(json['korisnik'] as Map<String, dynamic>),
    );

Map<String, dynamic> _$PaymentToJson(Payment instance) => <String, dynamic>{
      'paymentId': instance.paymentId,
      'metoda': instance.metoda,
      'datum': instance.datum.toIso8601String(),
      'iznos': instance.iznos,
      'korisnikId': instance.korisnikId,
      'korisnik': instance.korisnik,
    };
