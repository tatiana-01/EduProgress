export interface Seguimiento {
    nombre: string;
    descripcion: string;
}

export interface Comentario {
    profesora: string;
    tema: string;
    seguimientos: Seguimiento[];
    id: number;
    nota: number;
    categoria: string;
}