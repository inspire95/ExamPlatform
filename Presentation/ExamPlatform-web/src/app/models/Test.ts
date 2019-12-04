import { CategoryType } from "./CategoryType";

export class Test {
  testId: number;
  name: string;
  content: string;
  totalPointSum: number;
  time: number;  
  testQuestionIds: number[];
  requiredPercentage: number;
  testCategories: CategoryType[];
}
