class Helper {
  static String formatDate(DateTime d){
    return '${d.day}.${d.month}.${d.year}';
  }
  static String formatDateTime(DateTime d){
    return '${Helper.formatDate(d)} ${Helper.padZeros(d.hour)}:${Helper.padZeros(d.minute)}';
  }
  static String padZeros(int n, [int count = 2]){
    return n.toString().padLeft(count, '0');
  }
}