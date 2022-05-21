using System;

namespace NerdStore.Vendas.Domain
{
    public class Roteiro
    {
        /* DESENVOLVIMENTO DO DOMÍNIO DE VENDAS */

        /* PEDIDO - ITEM PEDIDO - VOUCHER */

        /* 
         *  Um item de um pedido representa um produto e pode conter mais de uma unidade.
         *  Independente da ação, um item precisa ser sempre válido:
         *      Possuir: Id e nome do produto, quantidade entre 1 e 15 unidades, valor maior que 0
         *  
         *  Um pedido enquanto não iniciado (processo de pagamento) está no estado de rascunho
         *  e deve pertencer a um cliente.
         *  
         *  1 - Adicionar Item
         *      1.1 - Ao adicionar um item é necessário calcular o valor total do pedido
         *      1.2 - Se um item já está na lista então deve acrescentar a quantidade do item no pedido
         *      1.3 - O item deve ter entre 1 e 15 unidades do produto
         *      
         *  2 - Atualização de Item
         *      2.1 - O item precisa estar na lista para ser atualizado
         *      2.2 - Um item pode ser atualizado contendo mais ou menos unidades do que anteriormente
         *      2.3 - Ao atualizar um item é necessário calcular o valor total do pedido
         *      
         *  3 - Remoção do Item
         *      3.1 - O item precisa estar na lista para ser enviado
         *      3.2 - Ao remover um item é necessário calcular o valor total do pedido
         *      
         *     
         *  
         */
    }
}
