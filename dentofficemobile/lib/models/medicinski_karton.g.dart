// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'medicinski_karton.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

MedicinskiKarton _$MedicinskiKartonFromJson(Map<String, dynamic> json) =>
    MedicinskiKarton(
      medicinskiKartonID: json['medicinskiKartonID'] as int,
      datum: DateTime.parse(json['datum'] as String),
      napomena: json['napomena'] as String,
    );

Map<String, dynamic> _$MedicinskiKartonToJson(MedicinskiKarton instance) =>
    <String, dynamic>{
      'medicinskiKartonID': instance.medicinskiKartonID,
      'datum': instance.datum.toIso8601String(),
      'napomena': instance.napomena,
    };
