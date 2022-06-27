// -- termin.dart --
import 'package:intl/intl.dart';
import 'package:json_annotation/json_annotation.dart';

import 'pacijent.dart';
import 'usluga.dart';

part 'termin.g.dart';

@JsonSerializable()
class Termin {
   int terminID;
   String razlog;
   bool? hitno;
   bool? odobreno;
   bool naCekanju;
   DateTime datumVrijeme;
   int pacijentId;
   Pacijent pacijent;
   int uslugaId;
   Usluga usluga;
   String uslugaNaziv;

   String get opis => "${DateFormat("dd-MM-yyyy").format(datumVrijeme)} (${(odobreno != null && odobreno!) ? "Odobren" : "Neodobren"})";

   Termin({required this.terminID,required this.razlog,required this.hitno,required this.odobreno,required this.naCekanju,required this.datumVrijeme,required this.pacijentId,required this.pacijent,required this.uslugaId,required this.usluga,required this.uslugaNaziv,});

   factory Termin.fromJson(Map<String, dynamic> json) => _$TerminFromJson(json);

   Map<String, dynamic> toJson() => _$TerminToJson(this);
}