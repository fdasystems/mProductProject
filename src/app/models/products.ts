export interface Product
{
    /*
    albumId: number;
    id?: number;
    title: string;
    url: string;
    thumbnailUrl: string

[Nombre]
[Descripcion]
[Codigo]
[RutaImagen]
pRECIOS.[PrecioVenta]

    */


     
    Id?: number;
    Codigo: string;
    Nombre: string;
    Descripcion: string;
    RutaImagen: string;
    PrecioVenta: number
}