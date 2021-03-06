import { ReactElement, useState } from "react";
import { ImageInfoType, ImageType } from "../../types/types";
import "./card.css";

export type ImageCardPropsType = {
  imageFile: ImageType;
  updateImageCallback: (updatedImage: ImageInfoType) => void;
  deleteImageCallback: (imageId: number) => void;
};

export const ImageCard = ({
  imageFile,
  updateImageCallback,
  deleteImageCallback,
}: ImageCardPropsType): ReactElement => {
  const [edit, setEdit] = useState<boolean>(false);
  const [title, setTitle] = useState<string>(imageFile.Title ?? "");
  const [description, setDescription] = useState<string>(
    imageFile.Description ?? ""
  );

  const updateImage = async () => {
    const updatedImage: ImageInfoType = {
      Id: imageFile.Id,
      Title: title,
      Description: description,
    };
    updateImageCallback(updatedImage);
  };

  return (
    <div className="container">
      <img
        className="image"
        alt="not found"
        src={`data:image/*;base64,${imageFile.ImageData}`}
      />
      <div className="inputs">
        <label htmlFor="title">Title*: </label>
        <input
          required
          disabled={!edit}
          id="title"
          value={title}
          onChange={(event) => setTitle(event.target.value)}
        />
      </div>
      <div className="inputs">
        <label htmlFor="description">Description: </label>
        <input
          disabled={!edit}
          id="description"
          value={description}
          onChange={(event) => setDescription(event.target.value)}
        />
      </div>
      <div className="inputs">
        <input
          type="button"
          disabled={!edit || title.length === 0}
          onClick={updateImage}
          title="Update Image Details"
          value="Update Image Details"
        />
        <input
          type="button"
          onClick={() => setEdit(!edit)}
          title={edit ? "Cancel" : "Edit Details"}
          value={edit ? "Cancel" : "Edit Details"}
        />
        <input
          type="button"
          disabled={edit}
          onClick={() => deleteImageCallback(imageFile.Id ?? -1)}
          title="Delete Image"
          value="Delete Image"
        />
      </div>
    </div>
  );
};
