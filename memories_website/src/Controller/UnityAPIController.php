<?php

namespace App\Controller;

use App\DTO\GuestEntryDTO;
use App\Entity\GuestEntry;
use App\Repository\GuestEntryRepository;
use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\HttpFoundation\JsonResponse;
use Symfony\Component\HttpFoundation\Request;
use Symfony\Component\HttpFoundation\Response;
use Symfony\Component\Routing\Attribute\Route;
use Symfony\Component\Serializer\SerializerInterface;

final class UnityAPIController extends AbstractController{
    #[Route('/unity/api/add-entry', name: 'app_unity_api_add_entry')]
    public function addEntry(
        Request $request,
        SerializerInterface $serializer,
        GuestEntryRepository $guestEntryRepository
    ): Response {
        $content = $request->getContent();
        if (empty($content)) {
            return new Response('No content', Response::HTTP_BAD_REQUEST);
        }

        $data = $serializer->deserialize($request->getContent(), GuestEntry::class, 'json');
        $data->setCreatedAt(new \DateTimeImmutable());

        $guestEntryRepository->save($data);

        return new Response();
    }

    #[Route('/unity/api/list-entries', name: 'app_unity_api_list_entries', methods: ['GET'])]
    public function listEntries(
        SerializerInterface $serializer,
        GuestEntryRepository $guestEntryRepository
    ): JsonResponse {
        $entries = $guestEntryRepository->findAll();
        $entriesDTO = [];
        foreach ($entries as $entry) {
            $entryDTO = new GuestEntryDTO();
            $entryDTO->setId($entry->getId());
            $entryDTO->setName($entry->getName());

            $entriesDTO[] = $entryDTO;
        }

        $wrapper = ['Items' => $entriesDTO];
        $data = $serializer->serialize($wrapper, 'json');

        return new JsonResponse($data);
    }
}
