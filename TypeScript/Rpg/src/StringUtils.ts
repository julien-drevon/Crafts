export function isNullOrEmpty(val: string): boolean {
  return !val || val.isNullOrEmpty();
}
export function isNotNullOrEmpty(val: string): boolean {
  if (val && val.isNotNullOrEmpty()) {
    return true;
  }

  return false;
}
declare global {
  export interface String {
    isNullOrEmpty(): boolean;
    isNotNullOrEmpty(): boolean;
  }
}

String.prototype.isNullOrEmpty = function () {
  return !this || this === "";
};

String.prototype.isNotNullOrEmpty = function () {
  return !this.isNullOrEmpty();
};
