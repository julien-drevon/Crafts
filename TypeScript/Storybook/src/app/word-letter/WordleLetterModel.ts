export enum WordleLetterPlacement{
  good,
  badPlacement,
  wrong  
}
export class WordleLetterModel {
  constructor(public letter: string = "", public placemet:WordleLetterPlacement=WordleLetterPlacement.good) { };

}
