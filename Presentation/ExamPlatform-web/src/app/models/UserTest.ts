import { CategoryType } from "./CategoryType";

export class UserTest {
  userTestId: string;
  totalPointAquired: number;
  autoPointAquired: number;
  manualPointAquired: number;
  isActive: boolean;
  userId: string;
  testId: number;
  startDate: Date;
  EndDate: Date;
  testSummaryTypeName: string;
  userTestStatusName: string;
    testsCategories: CategoryType[];
}