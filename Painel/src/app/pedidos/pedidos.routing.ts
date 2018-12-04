import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { PedidoListComponent } from './pedido-list/pedido-list.component';
import { PedidoListResolve } from './pedido-list/pedido-list.revolve';
import { PedidoFormComponent } from './pedido-form/pedido-form.component';
import { PedidoFormResolve } from './pedido-form/pedido-form.resolve';
import { ClientesAtivosResolve } from '../clientes/cliente/clientes-ativos.resolve';

const routes: Routes = [
    {
        path: '',
        component: PedidoListComponent,
        resolve: {
            pedidos: PedidoListResolve
        }
    },
    {
        path: 'novo-pedido',
        component: PedidoFormComponent,
        resolve: {
            pedido: PedidoFormResolve,
            clientes: ClientesAtivosResolve
        }
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class PedidosRoutingModule { }
