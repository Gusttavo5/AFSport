import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { BaseFormComponent } from 'src/app/core/base/base-form.component';
import { Pedido } from '../pedido/pedido';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PedidoService } from '../pedido/pedido.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Cliente } from 'src/app/clientes/cliente/cliente';
import { Produto } from 'src/app/produtos/produto/produto';
import { PedidoItem } from '../pedido/pedido-item';
import { ProdutoService } from 'src/app/produtos/produto/produto.service';

@Component({
    templateUrl: './pedido-form.component.html'
})
export class PedidoFormComponent implements BaseFormComponent<Pedido>, OnInit {
    @ViewChild('clienteInput') clienteInput: ElementRef<HTMLInputElement>;
    @ViewChild('idProduto') idProduto: ElementRef<HTMLInputElement>;
    @ViewChild('quantidade') quantidade: ElementRef<HTMLInputElement>;

    pedidoForm: FormGroup;
    pedido: Pedido;
    pedidoItens: PedidoItem[] = [];
    clientes: Cliente[];

    constructor(
        private formBuilder: FormBuilder,
        private pedidoService: PedidoService,
        private produtoService: ProdutoService,
        private activatedRoute: ActivatedRoute,
        private router: Router
    ) { }

    ngOnInit(): void {
        this.pedido = this.activatedRoute.snapshot.data.pedido;
        this.clientes = this.activatedRoute.snapshot.data.clientes;
        this.pedidoForm = this.formBuilder.group({
            idpedido: [this.pedido ? this.pedido.idPedido : 0],
            idCliente: [this.pedido ? this.pedido.idCliente : 1, Validators.required]
        });
        this.clienteInput.nativeElement.focus();
        this.quantidade.nativeElement.value = '1';
    }

    salvar() {
        var pedido = this.pedidoForm.getRawValue() as Pedido;
        if (pedido.idPedido)
            this.alterar(pedido);
        else
            this.inserir(pedido);
    }

    inserir(pedido: Pedido) {
        this.pedidoService.inserir(pedido)
            .subscribe(pedido => {
                swal("Enviada com sucesso!", "Pedido cadastrado com sucesso", "success");
                this.router.navigate(['/pedido']);
            }, err => {
                swal("Problemas para enviar!", err.error.msg, "error");
            });
    }

    alterar(pedido: Pedido) {
        this.pedidoService.alterar(pedido.idPedido, pedido)
            .subscribe(pedido => {
                swal("Enviada com sucesso!", "Pedido alterado com sucesso", "success");
                this.router.navigate(['/pedido']);
            }, err => {
                swal("Problemas para enviar!", err.error.msg, "error");
            });
    }

    adicionarProduto() {
        let quantidade = parseInt(this.quantidade.nativeElement.value);
        let idProduto = parseInt(this.idProduto.nativeElement.value);

        this.produtoService.listarPorId(quantidade)
            .subscribe(produto => {
                this.pedidoItens.push(<PedidoItem>{
                    isAtivo: true,
                    idProduto,
                    quantidade,
                    produto,
                });
            }, err => swal("Problemas para enviar!", "Produto não encontrado", "error"))

    }
}
