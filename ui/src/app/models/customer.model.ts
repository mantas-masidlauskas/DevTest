
export interface CustomerModel {
  customerId: number;
  name: string;
  type: CustomerType;
}

export enum CustomerType {
  Small = 0,
  Large = 1
}
