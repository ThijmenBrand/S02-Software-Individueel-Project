export default function formatDate(date: string): string {
  if (date == undefined) return "";

  const today = new Date();
  const inputDate = new Date(date);

  if (inputDate.setHours(0, 0, 0, 0) == today.setHours(0, 0, 0, 0))
    return date.split("T")[1];

  const day = date.split("T")[0].split("-").reverse().join("-").substring(0, 5);

  const time = date.split("T")[1].substring(0, 5);
  return day + " " + time;
};
