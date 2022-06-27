// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'dijagnoza.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Dijagnoza _$DijagnozaFromJson(Map<String, dynamic> json) => Dijagnoza(
      dijagnozaID: json['dijagnozaID'] as int,
      naziv: json['naziv'] as String,
      napomena: json['napomena'] as String,
    );

Map<String, dynamic> _$DijagnozaToJson(Dijagnoza instance) => <String, dynamic>{
      'dijagnozaID': instance.dijagnozaID,
      'naziv': instance.naziv,
      'napomena': instance.napomena,
    };
