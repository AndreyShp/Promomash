/* общие данные для шагов мастера */

export class UserWizardState {
  step: number;
  user: UserData;
}

export class UserData {
  id: number | null;
  login: string;
  password: string;
  regionId: number
}
