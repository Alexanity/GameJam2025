<?php

namespace App\DTO;

class ImageDTO
{
    const ASSET_PATH = 'files/images/';
    private ?string $path = null;

    private ?string $caption = null;

    public function getPath(): ?string
    {
        return $this->path;
    }

    public function setPath(string $path): void
    {
        $this->path = self::ASSET_PATH . $path;
    }

    public function getCaption(): ?string
    {
        return $this->caption;
    }

    public function setCaption(string $caption): void
    {
        $this->caption = $caption;
    }
}
