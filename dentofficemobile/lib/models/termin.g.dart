// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'termin.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Termin _$TerminFromJson(Map<String, dynamic> json) => Termin(
      terminID: json['terminID'] as int?,
      razlog: json['razlog'] as String,
      hitno: json['hitno'] as bool? ?? false,
      odobreno: json['odobreno'] as bool?,
      naCekanju: json['naCekanju'] as bool,
      datumVrijeme: DateTime.parse(json['datumVrijeme'] as String),
      pacijentId: json['pacijentId'] as int,
      pacijent: json['pacijent'] == null
          ? null
          : Pacijent.fromJson(json['pacijent'] as Map<String, dynamic>),
      uslugaId: json['uslugaId'] as int,
      usluga: json['usluga'] == null
          ? null
          : Usluga.fromJson(json['usluga'] as Map<String, dynamic>),
      uslugaNaziv: json['uslugaNaziv'] as String?,
    );

Map<String, dynamic> _$TerminToJson(Termin instance) => <String, dynamic>{
      'terminID': instance.terminID,
      'razlog': instance.razlog,
      'hitno': instance.hitno,
      'odobreno': instance.odobreno,
      'naCekanju': instance.naCekanju,
      'datumVrijeme': instance.datumVrijeme.toIso8601String(),
      'pacijentId': instance.pacijentId,
      'pacijent': instance.pacijent,
      'uslugaId': instance.uslugaId,
      'usluga': instance.usluga,
      'uslugaNaziv': instance.uslugaNaziv,
    };
