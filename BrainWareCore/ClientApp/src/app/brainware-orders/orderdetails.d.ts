
declare namespace Sales {
  interface OrderDetails {
    index: number;
    companyId: number;
    companyName: string;
    orderId: number;
    orderDescription: string;
    orderproductQuantity: number;
    orderproductPrice: number;
    orderproductTotalPrice: number;
    productId: number;
    productName: string;
  }
}
