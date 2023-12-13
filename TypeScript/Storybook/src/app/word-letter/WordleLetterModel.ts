export enum WordleLetterPlacement {
  good,
  badPlacement,
  wrong,
  empty
}
export class WordleLetterModel {
  constructor(public letter: string = "", public placement:WordleLetterPlacement=WordleLetterPlacement.empty) { }

}
