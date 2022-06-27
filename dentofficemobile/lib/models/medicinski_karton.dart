// -- medicinski_karton.dart --
import 'package:json_annotation/json_annotation.dart';

part 'medicinski_karton.g.dart';

@JsonSerializable()
class MedicinskiKarton {
  int medicinskiKartonID;
  DateTime datum;
  String napomena;

  MedicinskiKarton({required this.medicinskiKartonID,required this.datum,required this.napomena,});

  factory MedicinskiKarton.fromJson(Map<String, dynamic> json) => _$MedicinskiKartonFromJson(json);

  Map<String, dynamic> toJson() => _$MedicinskiKartonToJson(this);
}