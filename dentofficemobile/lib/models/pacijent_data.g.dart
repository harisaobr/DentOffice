// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'pacijent_data.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Pacijent_Data _$Pacijent_DataFromJson(Map<String, dynamic> json) =>
    Pacijent_Data(
      pacijentID: json['pacijentID'] as int,
      proteza: json['proteza'] as bool,
      aparatic: json['aparatic'] as bool,
      terapija: json['terapija'] as bool,
      korisnikID: json['korisnikID'] as int,
    );

Map<String, dynamic> _$Pacijent_DataToJson(Pacijent_Data instance) =>
    <String, dynamic>{
      'pacijentID': instance.pacijentID,
      'proteza': instance.proteza,
      'aparatic': instance.aparatic,
      'terapija': instance.terapija,
      'korisnikID': instance.korisnikID,
    };
