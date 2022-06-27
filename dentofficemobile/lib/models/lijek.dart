// -- lijek.dart --
import 'package:json_annotation/json_annotation.dart';

part 'lijek.g.dart';

@JsonSerializable()
class Lijek {
  int lijekID;
  String naziv;

  Lijek({required this.lijekID,required this.naziv,});

  factory Lijek.fromJson(Map<String, dynamic> json) => _$LijekFromJson(json);

  Map<String, dynamic> toJson() => _$LijekToJson(this);
}