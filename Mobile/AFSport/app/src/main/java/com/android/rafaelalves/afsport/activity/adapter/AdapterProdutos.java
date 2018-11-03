package com.android.rafaelalves.afsport.activity.adapter;

import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.android.rafaelalves.afsport.R;
import com.android.rafaelalves.afsport.activity.model.Produto;

import java.util.List;

public class AdapterProdutos extends RecyclerView.Adapter<AdapterProdutos.ViewHolderProdutos> {

    private List<Produto> listaProdutos;

    public AdapterProdutos(List<Produto>lista){
        this.listaProdutos = lista;
    }

    @NonNull
    @Override
    public ViewHolderProdutos onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View itemListaProdutos = LayoutInflater.from(parent.getContext()).inflate(R.layout.produtos_adapter, parent, false);
        return new ViewHolderProdutos(itemListaProdutos);
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolderProdutos holder, int position) {
        Produto produto = listaProdutos.get(position);

        holder.codigoProduto.setText(produto.getCodigoProduto());
        holder.nomeProduto.setText(produto.getNomeProduto());
        holder.descricaoProduto.setText(produto.getDescricaoProduto());
        holder.valorProduto.setText(produto.getValorProduto());
    }

    @Override
    public int getItemCount() {
        return listaProdutos.size();
    }

    public class ViewHolderProdutos extends RecyclerView.ViewHolder{

        TextView codigoProduto;
        TextView nomeProduto;
        TextView descricaoProduto;
        TextView valorProduto;

        public ViewHolderProdutos(View itemView) {
            super(itemView);
            codigoProduto = itemView.findViewById(R.id.txtCodigoProduto);
            nomeProduto = itemView.findViewById(R.id.txtNomeProduto);
            descricaoProduto = itemView.findViewById(R.id.txtDescricaoProduto);
            valorProduto = itemView.findViewById(R.id.txtValorProduto);
        }
    }

}
