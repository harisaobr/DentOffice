// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'usluga.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Usluga _$UslugaFromJson(Map<String, dynamic> json) => Usluga(
      uslugaID: json['uslugaID'] as int,
      naziv: json['naziv'] as String,
      cijena: Decimal.fromJson(json['cijena'].toString()),
    );

Map<String, dynamic> _$UslugaToJson(Usluga instance) => <String, dynamic>{
      'uslugaID': instance.uslugaID,
      'naziv': instance.naziv,
      'cijena': instance.cijena,
    };
