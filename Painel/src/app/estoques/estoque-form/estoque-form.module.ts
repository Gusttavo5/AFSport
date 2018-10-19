import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EstoqueFormComponent } from './estoque-form.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { MensagemModule } from 'src/app/shared/components/mensagem/mensagem.module';

@NgModule({
    declarations: [EstoqueFormComponent],
    imports: [
        CommonModule,
        RouterModule,
        ReactiveFormsModule,
        MensagemModule
    ]
})
export class EstoqueFormModule { }