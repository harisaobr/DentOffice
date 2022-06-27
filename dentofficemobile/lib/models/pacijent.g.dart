// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'pacijent.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Pacijent _$PacijentFromJson(Map<String, dynamic> json) => Pacijent(
      json['pacijentID'] as int,
      json['proteza'] as bool,
      json['aparatic'] as bool,
      json['terapija'] as bool,
      json['korisnikID'] as int,
      Korisnik.fromJson(json['korisnik'] as Map<String, dynamic>),
    );

Map<String, dynamic> _$PacijentToJson(Pacijent instance) => <String, dynamic>{
      'pacijentID': instance.pacijentID,
      'proteza': instance.proteza,
      'aparatic': instance.aparatic,
      'terapija': instance.terapija,
      'korisnikID': instance.korisnikID,
      'korisnik': instance.korisnik,
    };
