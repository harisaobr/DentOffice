// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'credit_card.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

CreditCard _$CreditCardFromJson(Map<String, dynamic> json) => CreditCard(
      creditCardId: json['creditCardId'] as int,
      korisnikId: json['korisnikId'] as int,
      ime: json['ime'] as String,
      korisnik: Korisnik.fromJson(json['korisnik'] as Map<String, dynamic>),
      payments: (json['payments'] as List<dynamic>)
          .map((e) => Payment.fromJson(e as Map<String, dynamic>))
          .toList(),
    );

Map<String, dynamic> _$CreditCardToJson(CreditCard instance) =>
    <String, dynamic>{
      'creditCardId': instance.creditCardId,
      'korisnikId': instance.korisnikId,
      'ime': instance.ime,
      'korisnik': instance.korisnik,
      'payments': instance.payments,
    };
