export function isNullOrEmpty(val: string): boolean {
  return !val || val.isEmpty();
}

export function isNotNullOrEmpty(val: string): boolean {
  if (val && val.isNotEmpty()) {
    return true;
  }

  return false;
}

declare global {
  export interface String {
    isEmpty(): boolean;
    isNotEmpty(): boolean;
  }
}

String.prototype.isEmpty = function () {
  return !this || this === "";
};

String.prototype.isNotEmpty = function () {
  return !this.isEmpty();
};
