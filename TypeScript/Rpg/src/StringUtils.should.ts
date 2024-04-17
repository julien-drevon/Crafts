import { isNotNullOrEmpty, isNullOrEmpty } from "./StringUtils";

describe("StringUtils should", () => {
  it("isNullOrEmpty", () => {
    expect(isNullOrEmpty(undefined)).toBe(true);
    expect(isNullOrEmpty(null)).toBe(true);
    expect(isNullOrEmpty(null)).toBe(true);
    expect(isNullOrEmpty("")).toBe(true);
    expect(isNullOrEmpty("notEmpty")).toBe(false);
  });

  it("isNotNullOrEmpty", () => {
    expect(isNotNullOrEmpty(undefined)).toBe(false);
    expect(isNotNullOrEmpty(null)).toBe(false);
    expect(isNotNullOrEmpty(null)).toBe(false);
    expect(isNotNullOrEmpty("")).toBe(false);
    expect(isNotNullOrEmpty("notEmpty")).toBe(true);
  });
});
