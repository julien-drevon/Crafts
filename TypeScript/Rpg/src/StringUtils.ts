export function isNullOrEmpty(val: string): boolean {
  return !val || val === "";
}
export function isNotNullOrEmpty(val: string): boolean {
  return !isNullOrEmpty(val);
}
