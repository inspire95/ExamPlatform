
export class Question {
  questionId: number;
  content: string;
  pointsSum: number;
  questionTypeId: number;
  categoryTypeIds: number[];
  isAssigned: boolean;
}
