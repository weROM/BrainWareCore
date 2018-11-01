
declare namespace Sales {
  interface Order {
    orderId: number;
    companyName: string;
    description: string;
    orderTotal: number;
    orderProducts: OrderProduct[];
  }
}
